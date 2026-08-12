using MonoMod.ModInterop;

namespace Sennmetals;

public class Exports {
    public static void ExportAtoms()
    {
        typeof(AtomExports).ModInterop();
    }

    [ModExportName("Sennmetals.Atoms")]
    public static class AtomExports
    {
        public static AtomType GetTyphor() => Atoms.typhor;
        public static AtomType GetSordi() => Atoms.sordi;
        public static AtomType GetEitros() => Atoms.eitros;
        public static AtomType GetRofor() => Atoms.rofor;
        public static AtomType GetSerket() => Atoms.serket;
    }
}
