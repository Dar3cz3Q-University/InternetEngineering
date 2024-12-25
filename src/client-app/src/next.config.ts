import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  reactStrictMode: true,

  webpack: (config: { watchOptions: { poll: number; aggregateTimeout: number; }; }, context: any) => {
    config.watchOptions = {
      poll: 800,
      aggregateTimeout: 200
    }
    return config
  }
};

export default nextConfig;
