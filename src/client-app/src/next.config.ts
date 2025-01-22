import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  reactStrictMode: true,
  images: {
    remotePatterns: [
      {
        protocol: 'http',
        hostname: 'maselniczka',
        port: '8080',
        pathname: '/uploads/images/**',
      },
    ],
  },
};

export default nextConfig;
