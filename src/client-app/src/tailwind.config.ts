import type { Config } from "tailwindcss";

export default {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      fontFamily: {
        roboto: ["var(--font-roboto)"],
        chakra: ["var(--font-chakra)"]
      },
      colors: {
        primary: "var(--color-primary)",
        secondary: "var(--color-secondary)",
        background_dark: "var(--color-background-dark)",
        background_light: "var(--color-background-light)",
        white: "var(--color-white)",
        black: "var(--color-black)",
        gray: "var(--color-gray)"
      },
    },
  },
  plugins: [],
} satisfies Config;
