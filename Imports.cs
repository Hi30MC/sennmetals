using MonoMod.ModInterop;
using PartType = class_139;
using System;

namespace Sennmetals;

class ImportManager
{
    public static void ImportNeuvolics()
    {
        typeof(NeuvolicsAtoms).ModInterop();
        typeof(NeuvolicsGlyphs).ModInterop();
    }

    [ModImportName("Neuvolics.Atoms")]
    public static class NeuvolicsAtoms
    {
        public static Func<AtomType> GetZephiron;
        public static Func<AtomType> GetFrixon;
        public static Func<AtomType> GetGelaron;
    }

    [ModImportName("Neuvolics.Glyphs")]
    public static class NeuvolicsGlyphs {
        public static PartType GetFixation;
    }
}
