using MonoMod.ModInterop;
using PartType = class_139;
using Texture = class_256;
using System;
using Quintessential;

namespace Sennmetals;

public class ImportManager
{
    public static void ImportNeuvolics()
    {
        typeof(NeuvolicsAtoms).ModInterop();
        typeof(NeuvolicsGlyphs).ModInterop();
        typeof(NeuvolicsFixationTextures).ModInterop();
        typeof(NeuvolicsSounds).ModInterop();
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

        public static Func<AtomType, int> GetNeumetalIndex;
    }

    [ModImportName("Neuvolics.Glyphs")]
    public static class NeuvolicsGlyphs
    {
        public static Func<PartType> GetFixation;
    }

    [ModImportName("Neuvolics.Sounds")]
    public static class NeuvolicsSounds
    {
        public static Func<Sound> GetFixationSound;
    }

    [ModImportName("Neuvolics.Textures.Fixation")]
    public static class NeuvolicsFixationTextures
    {
        public static Func<Texture> GetFixationBase;
        public static Func<Texture[]> GetFixationNets;
        public static Func<Texture> GetFixationConnectors;
        public static Func<Texture> GetFixationHoleBar;
        public static Func<Texture> GetFixationHoleNeumetalActive;
        public static Func<Texture> GetFixationHoleNeumetalInactive;
        public static Func<Texture> GetFixationHoleVolicActive;
        public static Func<Texture> GetFixationHoleFrixonHalfActive;
        public static Func<Texture> GetFixationHoleFrixonInactive;
        public static Func<Texture> GetFixationHoleGelaronHalfActive;
        public static Func<Texture> GetFixationHoleGelaronInactive;

        public static Func<Texture[]> GetFixationZephironIris;
        public static Func<Texture[]> GetFixationNeumetalIris;
    }
}
