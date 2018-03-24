using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour {

	public Texture2D circle_icon;
	public Texture2D cross_icon;
	public Texture2D blank;

	//ture denote the turn of ciccle and false cross
	private bool turn;
	//0:blank   1:circle   2:cross
	private int[,] state = new int[3, 3]; 

	// Use this for initialization
	void Start () {
		turn = true;
		Reset ();
	}

	void OnGUI () {
		//width(height) of the whole board
		int size_of_board = 210;
		//width(height) of each button
		int size_of_button = size_of_board / 3;
		int width_of_reset = size_of_board;
		int height_of_reset = 50;

		GUIStyle style1 = new GUIStyle ();
		style1.fontSize = 25;
		style1.normal.textColor = new Color (171f/256f, 241f/256f, 3f/256f);
		style1.alignment = TextAnchor.MiddleCenter;

		GUIStyle style2 = new GUIStyle ();
		style2.fontSize = 25;
		style2.normal.textColor = new Color (230f/256f, 154f/256f, 8f/256f);
		style2.alignment = TextAnchor.MiddleCenter;

		GUIStyle style3 = new GUIStyle ();
		style3.fontSize = 25;
		style3.normal.textColor = new Color (0, 0, 0);
		style3.alignment = TextAnchor.MiddleCenter;

		GUIStyle style4 = new GUIStyle ();
		style4.fontSize = 38;
		style4.normal.textColor = new Color (171f/256f, 241f/256f, 3f/256f);
		style4.alignment = TextAnchor.MiddleRight;

		GUIStyle style5 = new GUIStyle ();
		style5.fontSize = 38;
		style5.normal.textColor = new Color (230f/256f, 154f/256f, 8f/256f);
		style5.alignment = TextAnchor.MiddleCenter;

		GUIStyle style6 = new GUIStyle ();
		style6.fontSize = 38;
		style6.normal.textColor = new Color (171f/256f, 241f/256f, 3f/256f);
		style6.alignment = TextAnchor.MiddleLeft;



		//leftmost of the board
		float base_x = (Screen.width - size_of_board) / 2;
		//topest of the board
		float base_y = (Screen.height - size_of_board) / 2;

		if (GUI.Button (new Rect (base_x, base_y + 3 * size_of_button + 30, width_of_reset, height_of_reset), "Reset")) {
			Reset ();
		}

		GUI.Label (new Rect (base_x, base_y - 140, size_of_button, 50), "Tic", style4);
		GUI.Label (new Rect (base_x + size_of_button, base_y - 140, size_of_button, 50), "Tac", style5);
		GUI.Label (new Rect (base_x + 2 * size_of_button, base_y - 140, size_of_button, 50), "Toe", style6);

		int winner = judge ();
		if (winner == 1)
			GUI.Label (new Rect (base_x, base_y - 70, size_of_board, 50), "circle wins!", style1);
		else if (winner == 2)
			GUI.Label (new Rect (base_x, base_y - 70, size_of_board, 50), "cross wins!", style2);
		else if (is_tie())
			GUI.Label (new Rect (base_x, base_y - 70, size_of_board, 50), "Tie,please click Reset", style3);

		if (turn)
			GUI.Button (new Rect (base_x - size_of_button - 25, base_y + size_of_button , size_of_button, size_of_button), circle_icon);
		else
			GUI.Button (new Rect (base_x - size_of_button - 25, base_y + size_of_button , size_of_button, size_of_button), cross_icon);

		for (int row = 0; row < 3; ++row) {
			for (int col = 0; col < 3; ++col) {

				if (state [row, col] == 1) {
					GUI.Button (new Rect (base_x + col * size_of_button, base_y + row * size_of_button, size_of_button, size_of_button), circle_icon);
				}

				else if (state [row, col] == 2) {
					GUI.Button (new Rect (base_x + col * size_of_button, base_y + row * size_of_button, size_of_button, size_of_button), cross_icon);
				}

				else if (GUI.Button (new Rect (base_x + col * size_of_button, base_y + row * size_of_button, size_of_button, size_of_button), blank)) {
					if (winner == 0) {
						if (turn) {
							state [row, col] = 1;
						} else {
							state [row, col] = 2;
						}

						turn = !turn;
					}
				}
			}
		}

	}

	void Reset () {

		for (int row = 0; row < 3; ++row) {
			for (int col = 0; col < 3; ++col) {
				state [row, col] = 0;
			}
		}
	}

	//1:circle wins    2:cross wins    0:neither
	int judge() {
		
		for (int row = 0; row < 3; ++row) 
			if (state [row, 0] != 0 && state [row, 0] == state [row, 1] && state [row, 1] == state [row, 2])
				return state [row, 0];

		for (int col = 0; col < 3; ++col) 
			if (state [0, col] != 0 && state [0, col] == state [1, col] && state [1, col] == state [2, col])
				return state [0, col];
		
		if (state [0, 0] != 0 && state [0, 0] == state [1, 1] && state [1, 1] == state [2, 2])
			return state [0, 0];

		if (state [0, 2] != 0 && state [0, 2] == state [1, 1] && state [1, 1] == state [2, 0])
			return state [0, 2];

		return 0;
	}

	//to determine whether there exists a tie when neither player wins
	bool is_tie() {
		for (int row = 0; row < 3; ++row) {
			for (int col = 0; col < 3; ++col) {
				if (state [row, col] == 0)
					return false;
			}
		}

		return true;
	}
}
