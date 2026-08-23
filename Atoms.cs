using Quintessential;
using Brimstone;
namespace Sennmetals;

public static class Atoms {
    public static AtomType typhor, sordi, eitros, rofor, serket;

    public static bool IsSennmetal(AtomType type) {
        return type == Atoms.typhor || type == Atoms.sordi || type == Atoms.eitros || type == Atoms.rofor || type == Atoms.serket;
    }

    public static void LoadAtoms() {
        typhor = Brimstone.API.CreateMetalAtom(
            ID: 150,
            modName: "Sennmetals",
            name: "Typhor",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/typhor/typhor_difsym",
            pathToLightramp: "textures/atoms/Hi30MC/Sennmetals/typhor/typhor_lightramp",
            pathToRimlight: "textures/atoms/Hi30MC/Sennmetals/typhor/typhor_rimlight"
        );
        sordi = Brimstone.API.CreateMetalAtom(
            ID: 151,
            modName: "Sennmetals",
            name: "Sordi",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/sordi/sordi_difsym",
            pathToLightramp: "textures/atoms/Hi30MC/Sennmetals/sordi/sordi_lightramp",
            pathToRimlight: "textures/atoms/Hi30MC/Sennmetals/sordi/sordi_rimlight"
        );
        eitros = Brimstone.API.CreateMetalAtom(
            ID: 152,
            modName: "Sennmetals",
            name: "Eitros",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/eitros/eitros_difsym",
            pathToLightramp: "textures/atoms/Hi30MC/Sennmetals/eitros/eitros_lightramp",
            pathToRimlight: "textures/atoms/Hi30MC/Sennmetals/eitros/eitros_rimlight"
        );
        rofor = Brimstone.API.CreateMetalAtom(
            ID: 153,
            modName: "Sennmetals",
            name: "Rofor",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/rofor/rofor_difsym",
            pathToLightramp: "textures/atoms/Hi30MC/Sennmetals/rofor/rofor_lightramp",
            pathToRimlight: "textures/atoms/Hi30MC/Sennmetals/rofor/rofor_rimlight"
        );
        serket = Brimstone.API.CreateMetalAtom(
            ID: 154,
            modName: "Sennmetals",
            name: "Serket",
            pathToSymbol: "textures/atoms/Hi30MC/Sennmetals/serket/serket_difsym",
            pathToLightramp: "textures/atoms/Hi30MC/Sennmetals/serket/serket_lightramp",
            pathToRimlight: "textures/atoms/Hi30MC/Sennmetals/serket/serket_rimlight"
        );

        QApi.AddAtomType(typhor);
        QApi.AddAtomType(sordi);
        QApi.AddAtomType(eitros);
        QApi.AddAtomType(rofor);
        QApi.AddAtomType(serket);
    }
}
