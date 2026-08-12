using Quintessential;
using PartType = class_139;
using System;
using System.Text.RegularExpressions;

namespace Sennmetals;

public static class Glyphs {
#region GlyphMeta
    public static readonly HexIndex FixationHole1Hex = new(-1, 0);
    public static readonly HexIndex FixationHole2Hex = new(0, 0);
    public static readonly HexIndex FixationHole3Hex = new(1, 0);
    public static readonly HexIndex FixationZephironIrisHex = new(1, -2);
    public static readonly HexIndex FixationNeumetalIrisHex = new(-1, 2);
    public static readonly string oldFixationString = ImportManager.NeuvolicsGlyphs.GetFixation().field_1530;
    public static readonly string newFixationString = Regex.Replace(oldFixationString, "neu", "senneu") + " Inputting a pair of zephiron translates between most senneumetallic pairs.";
#endregion

#region LoadParts
    public static void LoadParts() {

        ImportManager.NeuvolicsGlyphs.GetFixation().field_1530 = class_134.method_253(newFixationString, string.Empty);

        QApi.RunDuringCycle(static (sim, part, pss, first) => {
            SolutionEditorBase seb = sim.field_3818;
            PartType type = part.method_1159();

            if (type == ImportManager.NeuvolicsGlyphs.GetFixation()  && first)
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
                // Brimstone.API.PlaySound(sim, ImportManager.NeuvolicsAtoms.GetFixationSound());
            }
        });
    }
#endregion
}
