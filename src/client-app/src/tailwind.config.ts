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
        primary: {
          DEFAULT: "var(--color-primary)",
          light: "var(--color-primary-light)"
        },
        secondary: "var(--color-secondary)",
        background_dark: "var(--color-background-dark)",
        background_light: "var(--color-background-light)",
        white: "var(--color-white)",
        black: "var(--color-black)",
        gray: "var(--color-gray)"
      },
      backgroundImage: {
        'sponsored-banner': "url(/images/sponsored-banner-background.jpg)",
        'promotion-example': "url(/images/promotion-example.jpg)"
      }
    },
  },
  plugins: [],
} satisfies Config;
