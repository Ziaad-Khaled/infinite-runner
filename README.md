# Infinite Runner
This project is a mini-game developed as part of the Advanced Computer Lab Winter 2022 course at the German University in Cairo, Faculty of Media Engineering and Technology.

## Project Objective

The main aim of this mini project is to test your ability to develop the core parts of a video game that can be deployed on both desktop and mobile platforms. The objective is to create a simple infinite runner game similar to Subway Surfers.
Gameplay Overview

The player controls a sphere that automatically moves forward on an infinite floor divided into three lanes. The objective is to dodge obstacles while managing both ability and health points to avoid losing the game. Collectibles can be found along the road, increasing the player's resources, while obstacles decrease the player's health points. The goal is to achieve the highest score possible before losing all health points.

## Game Preview


https://github.com/Ziaad-Khaled/infinite-runner/assets/77291238/c9351be7-1afc-45ef-a7ad-3c7e62d3c7b5



## Rules of Play

- The player views the game from a third-person perspective behind the sphere.
- The player automatically moves forward.
- The player can steer left and right to change lanes.
- The player starts with 5 health points and can collect health orbs to increase them by 1.
- The player loses 1, 2, or 3 health points depending on the type of obstacle they collide with.
- If the health points reach zero, the "Game Over" screen is displayed.
- The player's score increases by 1, 2, or 3 points based on the type of obstacle they avoid by jumping over.
- The player starts with 10 ability points and can collect ability orbs to increase them by 1.
- Jumping consumes 1 ability point, and the player can activate a special ability that consumes 5 ability points.
- The player can neither jump nor activate the special ability if they don't have enough ability points.
- Collectibles and obstacles are generated automatically and randomly throughout the game.
- Only one obstacle or collectible can exist on the same horizontal line.
- Obstacles can block one, two, or three lanes.

## Game Controls
### Windows:

- Move left: Left arrow key or "A" button
- Move right: Right arrow key or "D" button
- Jump: Spacebar
- Activate special ability: "Q" key
- Pause/resume: "ESC" key

### Android:

- Move left: Left button on the bottom-left of the screen
- Move right: Right button on the bottom-right of the screen
- Jump: Up button on the bottom-middle of the screen
- Activate special ability: Special Ability button on the bottom-middle of the screen
- Pause: Pause button on the top left/right of the screen

## Screens


1. Title Screen
    - Play
    - Options
        - How to Play: A brief description of the rules of play and the buttons needed to play the game.
        - Credits: Any audio sources, materials, or any external resources used should be credited.
        - Mute Sound: A toggle button that can mute/unmute all sounds within the game.
    - Quit

2. Gameplay HUD (Numerical Points)
    - Health Points
    - Score
    - Ability Points

3. Pause
    - Resume
    - Restart
    - Main Menu

4. Game Over
    - Score: the final score reached by the player should be displayed in the Game Over screen.
    - Restart
    - Main Menu

## Sounds

- Sound effects/feedback for collecting collectibles and hitting obstacles.
- Slow-paced track for the title, pause, and game over screens.
- Exciting and/or tensing soundtrack for the game.

## Cheats

Cheats are available only in the Windows version for testing purposes.

- Pressing "G" increases the player's health points by 1.
- Pressing "H" decreases the player's health points by 1.
- Pressing "J" increases the player's ability points by 1.
- Pressing "K" decreases the player's ability points by 1.
- Pressing "L" toggles the player's invincibility.
