/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Views/**/*.cshtml", // Monitora as views ASP.NET MVC
        "./wwwroot/**/*.js",   // Arquivos JavaScript no diretório wwwroot
    ],
  theme: {
    extend: {},
  },
  plugins: [],
}

