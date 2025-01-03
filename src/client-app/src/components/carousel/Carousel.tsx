import React from "react"
import useEmblaCarousel from "embla-carousel-react"
import { NextButton, PrevButton, usePrevNextButtons } from "./CarouselControls";
import { SnapDisplay, useSnapDisplay } from "./CarouselSnapDisplay";

const Carousel = (
    {children}: {children: React.ReactNode}
) => {
    const [emblaRef, emblaApi] = useEmblaCarousel({ dragFree: true});
    
    const {
        prevBtnDisabled,
        nextBtnDisabled,
        onPrevButtonClick,
        onNextButtonClick
    } = usePrevNextButtons(emblaApi);

    const {
        selectedSnap,
        snapCount
    } = useSnapDisplay(emblaApi);

    return (
        <section className="relative w-full">
            <div className="overflow-hidden" ref={emblaRef}>
                <div className="flex gap-[24px] py-[16px] ml-[24px] mr-[24px]">
                    {children}
                </div>
            </div>

            <div className="flex flex-row justify-between items-center mx-[24px]">
                <div>
                    <PrevButton onClick={onPrevButtonClick} disabled={prevBtnDisabled} />
                    <NextButton onClick={onNextButtonClick} disabled={nextBtnDisabled} />
                </div>
                <SnapDisplay
                    selectedSnap={selectedSnap}
                    snapCount={snapCount}
                />
            </div>
        </section>
    )
}

export default Carousel;