/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors');

export default {
	darkMode: ["class"],
	content: ["./src/**/*.{html,js,ts,jsx,tsx}"],
	theme: {
		fontFamily:{
			'sans': ['"Inter"', 'sans-serif'],
			'headline': ['Newake', 'sans-serif'],
		},
		extend: {
			borderRadius: {
				lg: 'var(--radius)',
				md: 'calc(var(--radius) - 2px)',
				sm: 'calc(var(--radius) - 4px)'
			},
			colors: {
				'primary-dark': 'var(--primary-dark)',        // Reference the CSS variable
				'primary-light': 'var(--primary-light)',      // Component background color
				'primary-muted': 'var(--primary-muted)',      // Used in header
				'primary-input': 'var(--primary-input)',      // Background color for input fields
				'input-active': 'var(--input-active)',        // Border color for input fields when active
				'primary-subtle': 'var(--primary-subtle)',    // Subtitle grey and placeholder text color
				'off-white': 'var(--off-white)',              // Main white text color
				'off-white-dark': 'var(--off-white-dark)',    // Darker white text color
				'button-default': 'var(--button-default)',    // Default button blue color
				'button-hover': 'var(--button-hover)',        // Button hover state blue color
				'button-active': 'var(--button-active)',      // Button active/clicked state blue color
				'button-border': 'var(--button-border)',      // Button outside border
				'error': 'var(--error)',                      // Red color for error messages
				'error-15': 'var(--error-15)',                // Red color for error messages 15% mark
				'error-30': 'var(--error-30)',                // Red color for error messages 30% mark
				'error-bright': 'var(--error-bright)',        // Red color for error icon on toast
				'success': 'var(--success)',                  // Green color for success toast
				'success-15': 'var(--success-15)',            // Green color for success toast 15% mark
				'success-30': 'var(--success-30)',            // Green color for success toast 30% mark
				'success-bright': 'var(--success-bright)',    // Green color for success icon on toast bright
				'secondary-accent': 'var(--secondary-accent)',  // Primary blue accent color Gradient/Borders
				'terciary-accent': 'var(--terciary-accent)',  // Secondary pink accent color Gradient/Borders
				'middle-accent': 'var(--middle-accent)',      // Middle accent color Gradient/Borders
			},
			boxShadow: {
				'custom-inner-sm': 'inset 0 1px 1px 0px rgba(255, 255, 255, 0.15)',
				'custom-inner-md': 'inset 0 2px 2px 0px rgba(255, 255, 255, 0.25)',
			},
		}
	},
	plugins: [require("tailwindcss-animate")],
}

