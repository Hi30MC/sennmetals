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

        Atoms.LoadAtoms();

        ImportManager.ImportNeuvolics();
        Exports.ExportAtoms();

        Logger.Log("Sennmetals: Neumetals crying at their reflection, transition done!");
    }

}
