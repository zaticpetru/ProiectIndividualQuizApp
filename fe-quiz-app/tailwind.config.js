module.exports = {
  purge: ['./src/**/*.{js,jsx}', './public/index.html'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      colors: () => ({
        'bg': '#121212',
        'error': '#CF6679'
      }),
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}