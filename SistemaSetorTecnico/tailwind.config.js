/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Views/**/*.cshtml", // Monitora as views ASP.NET MVC
        "./wwwroot/**/*.js",   // Arquivos JavaScript no diret�rio wwwroot
    ],
  theme: {
    extend: {},
  },
  plugins: [],
}

