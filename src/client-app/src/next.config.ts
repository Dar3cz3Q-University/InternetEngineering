import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  reactStrictMode: true,
  images: {
    remotePatterns: [
      {
        protocol: 'http',
        hostname: '192.168.0.5',
        port: '8080',
        pathname: '/uploads/images/**',
      },
    ],
  },
};

export default nextConfig;
