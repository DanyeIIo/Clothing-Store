module.exports = {
  purge: [],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      backgroundImage: theme => ({
      'home-page': "url('assets/pictures/home-bg.png')",
      clothing_bg: "url(assets/pictures/nigga.png)"
      }),
    fontFamily: theme =>({
      'custom': ['Poppins', 'Impact', 'Verdana', 'Georgia', 'Tahoma']
    }),
    backgroundColor: theme => ({
        'primary': '#3490dc',
        'deep-blue': '#0F0038',
        'danger': '#e3342f',
      })
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
