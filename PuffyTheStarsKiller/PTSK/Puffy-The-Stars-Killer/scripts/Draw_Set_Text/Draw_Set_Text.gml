/// @desc DrawSetColor(colour, font, halign, valign)
/// @param colour
/// @param font
/// @param halign
/// @param valign

// Allows one line setup of major text drawing vars.
// Requiring all four prevents silly coders from forgetting one
// And therefore creating a dumb dependecy on other event calls.
// (Then wodering why their text changes later in development.)

function Draw_Set_Text(colour, font, halign, valign) {
	draw_set_color(colour);
	draw_set_font(font);
	draw_set_halign(halign);
	draw_set_valign(valign);
}