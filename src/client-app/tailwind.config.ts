import type { Config } from "tailwindcss";

export default {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        c_primary: "#fe5c01",
        c_secondary: "#2e2e2e",
        c_background: "#111111",
        t_white: "#FFFFFF",
        t_black: "#000000",
        t_gray: "#666666"
      },
    },
  },
  plugins: [],
} satisfies Config;
