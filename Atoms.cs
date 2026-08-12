using Quintessential;
using Brimstone;
namespace Sennmetals;

public static class Atoms {
    public static AtomType typhor, sordi, eitros, rofor, serket;

    public static void LoadAtoms() {
        typhor = Brimstone.API.CreateNormalAtom(
            ID: 150,
            modName: "Sennmetals",
            name: "Typhor",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/hestium_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Sennmetals/copper_diffuse"
        );
        sordi = Brimstone.API.CreateNormalAtom(
            ID: 151,
            modName: "Sennmetals",
            name: "Sordi",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/iridium_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Sennmetals/copper_diffuse"
        );
        eitros = Brimstone.API.CreateNormalAtom(
            ID: 152,
            modName: "Sennmetals",
            name: "Eitros",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/mitrum_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Sennmetals/copper_diffuse"
        );
        rofor = Brimstone.API.CreateNormalAtom(
            ID: 153,
            modName: "Sennmetals",
            name: "Rofor",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/azulum_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Sennmetals/copper_diffuse"
        );
        serket = Brimstone.API.CreateNormalAtom(
            ID: 154,
            modName: "Sennmetals",
            name: "Serket",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/taceum_symbol",
            pathToDiffuse: "textures/atoms/Hi30MC/Sennmetals/copper_diffuse"
        );

        QApi.AddAtomType(typhor);
        QApi.AddAtomType(sordi);
        QApi.AddAtomType(eitros);
        QApi.AddAtomType(rofor);
        QApi.AddAtomType(serket);
    }
}
