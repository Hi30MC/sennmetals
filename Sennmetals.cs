using Quintessential;

namespace Sennmetals;

public class Sennmetals : QuintessentialMod
{

    public static readonly bool FTSIGCTULoaded = Brimstone.API.IsModLoaded("FTSIGCTU");

    public override void Load()
    {
        Logger.Log("Sennmetals: Opposing cultural norms!");
    }

    public override void PostLoad()
    {
        LoadMirrorRules();
    }
    public override void Unload() { }

    public override void LoadPuzzleContent()
    {
        Logger.Log("Sennmetals: Holding a mirror to the Neumetals...");

        // Logger.Log("Load Atoms");
        Atoms.LoadAtoms();
        // Logger.Log("Import Neuvolics");
        ImportManager.ImportNeuvolics();

        // Logger.Log("ExportAtoms");
        Exports.ExportAtoms();
        // Logger.Log("Load Parts");
        Glyphs.LoadParts();

        // Logger.Log("Load FTSICTGU map rules)
        LoadMapRules();

        // Logger.Log("GenerateLUTs");
        GlyphLUT.GenerateLUTs();



        Logger.Log("Sennmetals: Neumetals crying at their reflection, transition done!");
    }

    #region External Method Calls
    #region FTSIGCTU
    private static void LoadMapRules()
    {
        FTSIGCTU.Navigation.PartsMap.addPartHexRule(Glyphs.Fixation, FTSIGCTU.Navigation.PartsMap.glyphRule);
    }

    private static void LoadMirrorRules()
    {
        FTSIGCTU.MirrorTool.addRule(Glyphs.Fixation, FTSIGCTU.MirrorTool.mirrorVerticalPart0_0);
    }

    #endregion
    #endregion
}
