'use client';

import { MapContainer, Marker, TileLayer, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import {useRef, useEffect} from "react"

const DefaultIcon = L.icon({
    iconUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon.png',
    shadowUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png',
    iconAnchor: [12, 41]
});

L.Marker.prototype.options.icon = DefaultIcon;

type PropType = {
    latitude: number;
    longitude: number;
    onMapClick: (latitude: number, longitude: number) => void;
}

const Map = (props: PropType) => {
    const {
        latitude,
        longitude,
        onMapClick
    } = props;

    const mapRef = useRef<L.Map | null>(null);

    useEffect(() => {
        if (mapRef.current) {
            mapRef.current.setView([latitude, longitude], mapRef.current.getZoom());
        }
    }, [latitude, longitude])

    const normalizeLongitude = (lng: number) => {
        return ((lng + 180) % 360 + 360) % 360 - 180;
    }

    const MapEvents = () => {
        useMapEvents({
            click(e) {
                const {lat, lng} = e.latlng;
                onMapClick(lat, normalizeLongitude(lng));
            }
        })
        return null;
    }

    return (
        <MapContainer
            center={[latitude, longitude]}
            zoom={10}
            scrollWheelZoom={true}
            style={{ height: '100%', width: '100%' }}
            maxBounds={[
                [-90, -180],
                [90, 180]
            ]}
            maxBoundsViscosity={1.0}
            ref={map => {mapRef.current = map}}
        >
            <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
            <Marker position={[latitude, longitude]}>

            </Marker>
            <MapEvents />
        </MapContainer>
    );
};

export default Map;