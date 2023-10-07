/// @description Screen_Shake(Magnitude, Frames)
/// @arg Magnitude Sets the Strength of the Shake (radius in pixels)
/// @arg Frames Sets the Length of th Shake in Frames (60 = 1s at 60fps)

function fScreen_Shake(Magnitude, Frames) {
	
	//Set Primitive\\ 
	with (oCamera) {
		
		if (Magnitude > shake_remain) {
			
			shake_magnitude = Magnitude;
			shake_remain = Magnitude;
			shake_length = Frames;
			
		}
	
	}
	
}