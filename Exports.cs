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
        public static AtomType GetTyphor() => null;
        public static AtomType GetSordi() => null;
        public static AtomType GetEitros() => null;
        public static AtomType GetRofor() => null;
        public static AtomType GetSerket() => null;
    }
}
