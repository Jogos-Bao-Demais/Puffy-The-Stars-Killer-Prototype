function GetInput() {
	key_interact = keyboard_check_pressed(ord("E"))

	key_left = keyboard_check(ord("A")) || keyboard_check(vk_left)
	key_right = keyboard_check(ord("D")) ||	keyboard_check(vk_right)
	key_jump = keyboard_check(vk_space) || keyboard_check(ord("W")) || keyboard_check(vk_up)
}