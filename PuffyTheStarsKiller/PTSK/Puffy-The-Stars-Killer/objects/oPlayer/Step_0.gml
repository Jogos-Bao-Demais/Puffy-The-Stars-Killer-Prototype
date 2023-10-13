GetInput()

if (place_meeting(x + player_speed[HORIZONTAL_AXIS], y, pCollideable)) {	
	while (!place_meeting(x + sign(player_speed[HORIZONTAL_AXIS]), y, pCollideable)) {		
		x += sign(player_speed[HORIZONTAL_AXIS])			
	}		
	player_speed[@ HORIZONTAL_AXIS] = 0		
}	
	
x += player_speed[HORIZONTAL_AXIS]
	
// Vertical
if (place_meeting(x, y + player_speed[VERTICAL_AXIS], pCollideable)) {		
	while (!place_meeting(x, y + sign(player_speed[VERTICAL_AXIS]), pCollideable)) {		
		y += sign(player_speed[@ VERTICAL_AXIS])          
	}
	player_speed[@ VERTICAL_AXIS] = 0  
}
	
y += player_speed[VERTICAL_AXIS]  

var _move_direction = key_right - key_left

player_speed[VERTICAL_AXIS] += GRAVITY
can_jump--

show_debug_message(_move_direction)

if _move_direction != 0 {
	show_debug_message("uai")
	player_speed[HORIZONTAL_AXIS] += _move_direction * acceleration
	player_speed = clamp(player_speed[HORIZONTAL_AXIS], -max_speed, max_speed)
} else {
	player_speed[HORIZONTAL_AXIS] = lerp(player_speed[HORIZONTAL_AXIS], 0, move_friction)
}

if (can_jump > 0) && (key_jump) {
	player_speed[VERTICAL_AXIS] = jump_speed
	can_jump = 0
}

if place_meeting(x, y + 1, pCollideable) {
	can_jump = 10
}