/// @description Screen_Shake(_magnitude, _frames)
/// @arg _magnitude Sets the Strength of the Shake (radius in pixels)
/// @arg _frames Sets the Length of th Shake in _frames (60 = 1s at 60fps)
function screen_shake(_magnitude, _frames) {
	//Set Primitive\\ 
	with (oCamera) {
		if (_magnitude > shake_remain) {
			shake_magnitude = _magnitude;
			shake_remain = _magnitude;
			shake_length = _frames;
		}
	}
}