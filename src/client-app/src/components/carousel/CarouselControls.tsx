import { IconButton, IconButtonProps } from "@mui/material"
import NavigateNextIcon from '@mui/icons-material/NavigateNext';
import NavigateBeforeIcon from '@mui/icons-material/NavigateBefore';
import React from "react";
import { EmblaCarouselType } from "embla-carousel";

type UsePrevNextButtonsType = {
    prevBtnDisabled: boolean;
    nextBtnDisabled: boolean;
    onPrevButtonClick: () => void;
    onNextButtonClick: () => void;
}

const usePrevNextButtons = (
    emblaApi: EmblaCarouselType | undefined
): UsePrevNextButtonsType => {
    const [prevBtnDisabled, setPrevBtnDisabled] = React.useState<boolean>(true);
    const [nextBtnDisabled, setNextBtnDisabled] = React.useState<boolean>(true);

    const onPrevButtonClick = React.useCallback(() => {
        if (!emblaApi) return;
        emblaApi.scrollPrev();
    }, [emblaApi]);

    const onNextButtonClick = React.useCallback(() => {
        if (!emblaApi) return;
        emblaApi.scrollNext();
    }, [emblaApi]);

    const onSelect = React.useCallback((emblaApi: EmblaCarouselType) => {
        setPrevBtnDisabled(!emblaApi.canScrollPrev());
        setNextBtnDisabled(!emblaApi.canScrollNext());
    }, []);

    React.useEffect(() => {
        if (!emblaApi) return;

        onSelect(emblaApi);
        emblaApi.on("reInit", onSelect).on("select", onSelect);
    }, [emblaApi, onSelect]);

    return {
        prevBtnDisabled,
        nextBtnDisabled,
        onPrevButtonClick,
        onNextButtonClick
    }
}


const PrevButton: React.FC<IconButtonProps> = (props) => {
    const { children, ...restProps} = props;

    return (
        <IconButton
            {...restProps}
            sx={{
                color: "primary.main"
            }}
        >
            <NavigateBeforeIcon fontSize="inherit" />
        </IconButton>
    )
}

const NextButton: React.FC<IconButtonProps> = (props) => {
    const { children, ...restProps} = props;

    return (
        <IconButton
            {...restProps}
            sx={{
                color: "primary.main"
            }}
        >
            <NavigateNextIcon fontSize="inherit" />
        </IconButton>
    )
} 

export {usePrevNextButtons, PrevButton, NextButton}