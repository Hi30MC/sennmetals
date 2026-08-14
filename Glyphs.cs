using Quintessential;
using PartType = class_139;
using Texture = class_256;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Sennmetals;

public static class Glyphs
{
    #region GlyphMeta
    public static readonly HexIndex FixationHole1Hex = new(-1, 0);
    public static readonly HexIndex FixationHole2Hex = new(0, 0);
    public static readonly HexIndex FixationHole3Hex = new(1, 0);
    public static readonly HexIndex FixationZephironIrisHex = new(1, -2);
    public static readonly HexIndex FixationNeumetalIrisHex = new(-1, 2);

    public static readonly Texture FixationZephironHalfActive = Brimstone.API.GetTexture("textures/atoms/Hi30MC/Sennmetals/zephiron_half_active");
    public static readonly Texture FixationZephironInactive = Brimstone.API.GetTexture("textures/atoms/Hi30MC/Sennmetals/zephiron_inactive");

    public static readonly string oldFixationString = ImportManager.NeuvolicsGlyphs.GetFixation().field_1530;
    public static readonly string newFixationString = Regex.Replace(oldFixationString, "neu", "senneu")
                                                    + " Inputting a pair of zephiron translates between most senneumetallic pairs.";
    #endregion

    internal static HashSet<HexIndex> OccupiedHexes = new();
    public static bool OccupiedHexesStale = true;

    #region LoadParts
    public static void LoadParts()
    {
        PartType Fixation = ImportManager.NeuvolicsGlyphs.GetFixation();

        Fixation.field_1530 = class_134.method_253(newFixationString, string.Empty);

        // Logger.Log("removing fixation clones");
        QApi.PartRenderers.RemoveAll(x => Fixation.Equals(x));

        // Logger.Log("readding the correct fixation");
        QApi.AddPartType(Fixation, static (part, pos, editor, renderer) =>
        {
            // hold on to your butts!
            // Logger.Log("hold on to your butts");
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out class_236 partDataWrapper, out float time);

            if (OccupiedHexesStale)
            {
                OccupiedHexes.Clear();
                OccupiedHexes.UnionWith(editor.method_502().method_1947(struct_18.field_1431, (enum_137)0));
                OccupiedHexesStale = false;
            }

            int invertedNetMask = 0;

            HexIndex[] nettingHexes = new HexIndex[4] { new(0, 1), new(-1, 1), new(0, -1), new(1, -1) };

            // Logger.Log("check if live");
            IScreen TOS = GameLogic.field_2434.method_938();

            if (TOS is not SolutionEditorScreen)
            {
                // Not interacting with it, not dragging
                goto NetRemoval;
            }

            interface_0 mode = ((SolutionEditorScreen)TOS).field_4010;

            if (mode is not PartDraggingInputMode)
            {
                // not dragging at all
                goto NetRemoval;
            }


            // Logger.Log("check dragging");
            PartDraggingInputMode drag = (PartDraggingInputMode)mode;
            if (((List<PartDraggingInputMode.DraggedPart>)typeof(PartDraggingInputMode).GetField("field_2712", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(drag)).Any((d) => d.field_2722 == part))
            {
                // we are dragging, and this part is in it.
                goto FixationDrawing;
            }
            // Logger.Log("remove nets");
        NetRemoval:
            for (int i = 0; i < nettingHexes.Length; i++)
            {
                if (OccupiedHexes.Contains(part.method_1184(nettingHexes[i])))
                {
                    // if hex contains a part, disable it
                    invertedNetMask |= 1 << i;
                }
            }

            // Logger.Log("draw fix");
        FixationDrawing:
                              // NDZGF
            int atomsPresent = 0b00000;
            HexIndex[] holes = new HexIndex[] { FixationHole1Hex, FixationHole2Hex, FixationHole3Hex };
            foreach (HexIndex h in holes)
            {
                foreach (Molecule m in editor.method_507().method_483())
                {
                    if (m.method_1100().Count == 1 && m.method_1100().TryGetValue(part.method_1184(h), out Atom a))
                    {
                        // Logger.Log("if atom on top?");
                        AtomType aT = a.field_2275;
                        if (aT == ImportManager.NeuvolicsAtoms.GetFrixon())
                        {
                            atomsPresent |= (atomsPresent & 0b00001) != 0 ? 0b01000 : 0b00001;
                        }
                        else if (aT == ImportManager.NeuvolicsAtoms.GetGelaron())
                        {
                            atomsPresent |= (atomsPresent & 0b00010) != 0 ? 0b0100 : 0b00010;
                        }
                        else if (aT == ImportManager.NeuvolicsAtoms.GetZephiron())
                        {
                            atomsPresent |= (atomsPresent & 0b00100) != 0 ? 0b01000 : 0b00100;
                        }
                        else if (ImportManager.NeuvolicsAtoms.GetNeumetalIndex(aT) != -1)
                        {
                            atomsPresent |= 0b10000;
                        }
                        else if (Atoms.IsSennmetal(aT))
                        {
                            atomsPresent |= 0b10000;
                        }
                    }
                }
            }

            // Logger.Log("drawing shit");
            Vector2 pivot = new(122, 191);
            Vector2 offset = Vector2.Zero;
            // Logger.Log("draw base");
            renderer.method_523(ImportManager.NeuvolicsFixationTextures.GetFixationBase(), offset, pivot, 0);


            for (int i = 0; i < nettingHexes.Length; i++)
            {
                if (((invertedNetMask >> i) & 1) == 0)
                {
                    // Logger.Log("draw net" + i);
                    renderer.method_523(ImportManager.NeuvolicsFixationTextures.GetFixationNets()[i], offset, pivot, 0);
                }
            }

            // input rendering
            // Logger.Log("input rendering");
            {
                class_256 neumetalReadout = (atomsPresent & 0b10000) != 0
                                           ? ImportManager.NeuvolicsFixationTextures.GetFixationHoleNeumetalInactive()
                                           : ImportManager.NeuvolicsFixationTextures.GetFixationHoleNeumetalActive();
                class_256 volicReadout = ImportManager.NeuvolicsFixationTextures.GetFixationHoleVolicActive();
                // Logger.Log("Checking atomsPresent: " + (atomsPresent & 15));
                switch (atomsPresent & 0b1111)
                {     // 0bDZGF
                    case 0b0001:
                        // frixon x1
                        volicReadout = ImportManager.NeuvolicsFixationTextures.GetFixationHoleFrixonHalfActive();
                        break;
                    case 0b0010:
                        // gelaron x1
                        volicReadout = ImportManager.NeuvolicsFixationTextures.GetFixationHoleGelaronHalfActive();
                        break;
                    case 0b0100:
                        // zephiron x1
                        volicReadout = FixationZephironHalfActive;
                        break;
                    case 0b1001:
                        // frixon x2
                        volicReadout = ImportManager.NeuvolicsFixationTextures.GetFixationHoleFrixonInactive();
                        break;
                    case 0b1010:
                        // gelaron x2
                        volicReadout = ImportManager.NeuvolicsFixationTextures.GetFixationHoleGelaronInactive();
                        break;
                    case 0b1100:
                        //zephiron x2
                        volicReadout = FixationZephironInactive;
                        break;
                    default:
                        // 0000: no volics are present.
                        // 0011: 1 frixon and 1 gelaron are present, invalid.
                        // 0101: 1 frixon and 1 zephiron are present, invalid.
                        // 0110: 1 gelaron and 1 zephiron are present, invalid.
                        // 0111: 1 frixon, 1 gelaron, 1 zephiron are present, invalid.
                        // 1000: impossible state. (double with no atoms on)
                        // 1011: 2 frix 1 gel or vice versa, invalid
                        // 1101: 2 zeph 1 frix or vice versa, invalid
                        // 1110: 2 zeph 1 gel or vice versa, invalid.
                        // 1111: impossible state (double with all three atoms on, impossible by pidgeonhole).
                        break;
                }
                foreach (HexIndex h in holes)
                {
                    renderer.method_530(class_238.field_1989.field_90.field_255.field_293, h, 0);
                    renderer.method_529(ImportManager.NeuvolicsFixationTextures.GetFixationHoleBar(), h, Vector2.Zero);
                    renderer.method_529(neumetalReadout, h, Vector2.Zero);
                    renderer.method_529(volicReadout, h, Vector2.Zero);
                }
            }

            // irises
            // Logger.Log("draw irises");
            Brimstone.API.DrawIris(renderer, partDataWrapper, FixationZephironIrisHex, time,
                                   ImportManager.NeuvolicsFixationTextures.GetFixationZephironIris(),
                                   pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);

            Brimstone.API.DrawIris(renderer, partDataWrapper, FixationNeumetalIrisHex, time,
                                   ImportManager.NeuvolicsFixationTextures.GetFixationNeumetalIris(),
                                   pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[1]) : struct_18.field_1431);

            renderer.method_523(ImportManager.NeuvolicsFixationTextures.GetFixationConnectors(), offset, pivot, 0);

        });

        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            SolutionEditorBase seb = sim.field_3818;
            PartType type = part.method_1159();

            if (type == ImportManager.NeuvolicsGlyphs.GetFixation() && first)
            {
                // Logger.Log("fixation found");
                HexIndex hLeft = part.method_1184(FixationHole1Hex);
                HexIndex hCenter = part.method_1184(FixationHole2Hex);
                HexIndex hRight = part.method_1184(FixationHole3Hex);
                HexIndex iZ = part.method_1184(FixationZephironIrisHex);
                HexIndex iN = part.method_1184(FixationNeumetalIrisHex);

                if (sim.FindAtom(iZ).method_1085()
                    || sim.FindAtom(iN).method_1085()) // blocked
                {
                    return;
                }
                // Logger.Log("Valid Outputs");
                if (!sim.FindAtom(hLeft).method_99(out AtomReference hLeftAtom)      // no left
                    || !sim.FindAtom(hCenter).method_99(out AtomReference hCenterAtom)  // no center
                    || !sim.FindAtom(hRight).method_99(out AtomReference hRightAtom) // no right
                    || hLeftAtom.field_2281 // left bondy
                    || hLeftAtom.field_2282 // left grabby
                    || hLeftAtom.field_2281 // center bondy
                    || hLeftAtom.field_2282 // center grabby
                    || hLeftAtom.field_2281 // right bondy
                    || hLeftAtom.field_2282) // right grabby
                {
                    return;
                }
                // Logger.Log("Valid Inputs"  + " " +  hLeftAtom.field_2280.ToString()  + " " +   hRightAtom.field_2280.ToString()  + " " +   hCenterAtom.field_2280.ToString());
                if (!GlyphLUT.FixationLUT.TryGetValue(
                    new Tuple<AtomType, AtomType, AtomType>(hLeftAtom.field_2280, hRightAtom.field_2280, hCenterAtom.field_2280),
                    out AtomType output))
                {
                    return;
                }
                // Logger.Log("Valid Output");
                Logger.Log(output.ToString());

                Brimstone.API.RemoveAtom(hLeftAtom);
                Brimstone.API.RemoveAtom(hCenterAtom);
                Brimstone.API.RemoveAtom(hRightAtom);
                // Logger.Log("deleted atoms");

                Brimstone.API.DrawFallingAtom(seb, hLeftAtom);
                Brimstone.API.DrawFallingAtom(seb, hCenterAtom);
                Brimstone.API.DrawFallingAtom(seb, hRightAtom);
                // Logger.Log("drew falling atoms");

                Brimstone.API.AddSmallCollider(sim, part, FixationZephironIrisHex);
                Brimstone.API.AddSmallCollider(sim, part, FixationNeumetalIrisHex);
                // Logger.Log("Add Small Collider falling atoms");

                pss.field_2743 = true;
                pss.field_2744 = new AtomType[2] { ImportManager.NeuvolicsAtoms.GetZephiron(), output };
                // Logger.Log("sent to render");
                Brimstone.API.PlaySound(sim, ImportManager.NeuvolicsSounds.GetFixationSound());
                // Logger.Log("sound played");
            }
        });
    }
    #endregion
}
