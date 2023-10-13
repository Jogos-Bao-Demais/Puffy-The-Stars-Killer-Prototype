function fKillPlayer() {
	
	with (oGun)
		instance_destroy();

	instance_change(oPDead, true);

	direction = point_direction(other.x, other.y, x, y)

	player_speed[H] = lengthdir_x(6, direction)
	player_speed[V] = lengthdir_y(4, direction) - 6

	if (sign(player_speed[H]) != 0)
		image_xscale = sign(player_speed[H]);

	life = 0;
}