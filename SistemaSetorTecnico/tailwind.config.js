/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Views/**/*.cshtml", // Monitora as views ASP.NET MVC
        "./wwwroot/**/*.js",   // Arquivos JavaScript no diretório wwwroot
    ],
    theme: {
        extend: {
            screens: {
                '3xl': '1920px',
                '2xl': '1536px',
                'xl': '1280px',
                'lg': '1024px',
                'md': '768px',
                'sm': '640px'
            },
        },
    },
    plugins: [],
}

