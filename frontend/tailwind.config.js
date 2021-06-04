module.exports = {
  purge: [],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      backgroundImage: theme => ({
      'home-page': "url('assets/pictures/home-bg.png')",
      'home-page-fhd': "url('assets/pictures/home-fhd.png')",
      'clothing-bg': "url(assets/pictures/nigga.png)"
      }),
    fontFamily: theme =>({
      'verdana': ['Verdana'],
      'poppy': ['Poppins'],
      'impact': ['Impact'],
      'georgia': ['Georgia'],
      'tahoma': ['Tahoma']
    }),
    backgroundColor: theme => ({
        'deep-blue': '#0F0038',
        'blue-black': '#31225E',
        'footer-purple': '#31225E'
      })
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
