const getCurrentLocation = (): Promise<{ latitude: number; longitude: number }> => {
    return new Promise((resolve) => {
        if (!navigator.geolocation) {
            console.warn("Geolocation is not supported by this browser.");
            resolve({ latitude: 0, longitude: 0 });
        }

        navigator.geolocation.getCurrentPosition(
            (position) => {
                const { latitude, longitude } = position.coords;
                resolve({ latitude, longitude });
            },
            () => {
                console.warn("Permission denied for geolocation.");
                resolve({ latitude: 0, longitude: 0 });
            },
            {
                enableHighAccuracy: true,
                timeout: 25000
            }
        );
    });
};

export {getCurrentLocation}