import { EmblaCarouselType } from "embla-carousel";
import React from "react";

type UseSnapDisplayType = {
    selectedSnap: number;
    snapCount: number;
}

const useSnapDisplay = (
    emblaApi: EmblaCarouselType | undefined
): UseSnapDisplayType => {
    const [selectedSnap, setSelectedSnap] = React.useState<number>(0);
    const [snapCount, setSnapCount] = React.useState<number>(0);

    const updateScrollSnapState = React.useCallback((emblaApi: EmblaCarouselType) => {
        setSnapCount(emblaApi.scrollSnapList().length);
        setSelectedSnap(emblaApi.selectedScrollSnap());
    }, []);

    React.useEffect(() => {
        if (!emblaApi) return;

        updateScrollSnapState(emblaApi);
        emblaApi.on("select", updateScrollSnapState);
        emblaApi.on("reInit", updateScrollSnapState);
    }, [emblaApi, updateScrollSnapState]);

    return {
        selectedSnap,
        snapCount
    };
}

type PropType = {
    selectedSnap: number;
    snapCount: number;
}

const SnapDisplay: React.FC<PropType> = (props) => {
    const {selectedSnap, snapCount} = props;

    return (
        <div>
            <p className="font-chakra opacity-70 mr-[8px]">{selectedSnap + 1} / {snapCount}</p>
        </div>
    );
}

export {useSnapDisplay, SnapDisplay};