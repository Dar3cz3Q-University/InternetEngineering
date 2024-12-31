import MainProviders from "@/components/providers/MainProviders";
import type { Metadata } from "next";
import { Chakra_Petch, Roboto } from "next/font/google";
import "./globals.css";

const chakraPetch = Chakra_Petch({
  variable: "--font-chakra",
  subsets: ["latin"],
  weight: ["300", "400", "500", "600", "700"]
})

const roboto = Roboto({
  variable: "--font-roboto",
  subsets: ['latin'],
  weight: ['100', '300', '400', '500', '700', '900']
});

export const metadata: Metadata = {
  title: "Maselniczka",
  description: "Projekt na studia",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`${chakraPetch.variable} ${roboto.variable} antialiased`}
      >
        <MainProviders>
          {children}
        </MainProviders>
      </body>
    </html>
  );
}
