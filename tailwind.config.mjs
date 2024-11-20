/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class', // or 'media' or 'class'
  content: [
    './Views/**/*.cshtml',
    './Views/**/*.html',
    './wwwroot/**/*.js',
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
