/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      colors: {
        primary: "#13ec80",
        "background-light": "#f6f8f7",
        "background-dark": "#102219",
        "text-light": "#0d1b14",
        "text-dark": "#e7f3ed",
        "subtle-light": "#4c9a73",
        "subtle-dark": "#a0d1b9",
        "border-light": "#cfe7db",
        "border-dark": "#2a4b3a",
        "surface-light": "#ffffff",
        "surface-dark": "#1a2c23",
        "text-light-primary": "#0d1b14",
        "text-dark-primary": "#e7f3ed",
        "text-light-secondary": "#4c9a73",
        "text-dark-secondary": "#a2cbb5",
        accent: "#4CAF50"
      },
      fontFamily: {
        display: ["Manrope", "sans-serif"]
      },
      borderRadius: {
        DEFAULT: "0.25rem",
        lg: "0.5rem",
        xl: "0.75rem",
        full: "9999px"
      }
    }
  },
  darkMode: "class",
  plugins: [require("@tailwindcss/forms"), require("@tailwindcss/container-queries")]
};
