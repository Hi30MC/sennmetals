using Quintessential;

namespace Sennmetals;

public class Sennmetals : QuintessentialMod
{

    public override void Load()
    {
        Logger.Log("Sennmetals: Opposing cultural norms!");
    }

    public override void PostLoad() { }
    public override void Unload() { }

    public override void LoadPuzzleContent()
    {
        Logger.Log("Sennmetals: Holding a mirror to the Neumetals...");

        // Logger.Log("Load Atoms");
        Atoms.LoadAtoms();
        // Logger.Log("Import Neuvolics");
        ImportManager.ImportNeuvolics();

        // Logger.Log("Load Parts");
        Glyphs.LoadParts();
        // Logger.Log("ExportAtoms");
        Exports.ExportAtoms();

        // Logger.Log("GenerateLUTs");
        GlyphLUT.GenerateLUTs();

        Logger.Log("Sennmetals: Neumetals crying at their reflection, transition done!");
    }

}
