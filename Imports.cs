using MonoMod.ModInterop;
using PartType = class_139;
using System;
using Quintessential;

namespace Sennmetals;

public class ImportManager
{
    public static void ImportNeuvolics()
    {
        // Logger.Log("Importing Neuvolics");
        typeof(NeuvolicsAtoms).ModInterop();
        // Logger.Log("Imported Atoms");
        typeof(NeuvolicsGlyphs).ModInterop();
        // Logger.Log("Imported Glyphs");
        // typeof(NeuvolicsSounds).ModInterop();
    }

    [ModImportName("Neuvolics.Atoms")]
    public static class NeuvolicsAtoms
    {
        public static Func<AtomType> GetZephiron;
        public static Func<AtomType> GetFrixon;
        public static Func<AtomType> GetGelaron;

        public static Func<AtomType> GetMitrum;
        public static Func<AtomType> GetIridium;
        public static Func<AtomType> GetHestium;
        public static Func<AtomType> GetAzulum;
        public static Func<AtomType> GetTaceum;
    }

    [ModImportName("Neuvolics.Glyphs")]
    public static class NeuvolicsGlyphs
    {
        public static Func<PartType> GetFixation;
    }

    // [ModImportName("Neuvolics.Sounds")]
    // public static class NeuvolicsSounds
    // {
    //     public static Func<Sound> GetFixationSound;
    // }
}
