# <h1 align="center">Jump Masters Documentation</h1>
<h2 align="center" dir="auto"><strong><code>Unity Engine Game Project</code></strong></h2>


<div class="Header Image">
  <a draggable="false" href="https://novalen.itch.io/jump-masters"><img width="1280" height="480" alt="Untitled design (2)" src="https://github.com/user-attachments/assets/a5da268d-45ba-43cb-9315-659c8c0825e3" /></a>
</div>

<h2 align="center" dir="auto"> Overview </h2>
<h2 align="center" dir="auto"><strong>Genre: <code>2D Side-Scroller</code> <code>Action-Adventure</code> <code>Platformer</code></h2>
<h2 align="center" dir="auto"><strong>Role: <code>Gameplay and UI Programming</code></h2>
<p dir="auto">Here is my Unity Engine 6 project I have been working on called Jump Masters for over a month, Jump Masters! This was a little challenge for myself because I wanted to see how fast I can make a playable game within a short period of time. After developing and design the core game mechanics and systems. I then went on to look for aesthetically pleasing assets to help make the game look fun and interesting to play. All assets were taken from the unity asset store, but the beck-end development was all done by my in visual studio using C#. I had a lot of fun developing this project because it is a simple and straight forward platformer with the main focus of the game encouraging the player to get to the end of the goal. The game for right now has a end credits but I plan on adding more characters with different abilities depending on which character the player chooses. Its still in development and I plan on showcasing more in the future.</p>
<br>


<h2 align="center" dir="auto"> Feature </h2>
<h3 align="left" dir="auto"> Gameplay Programming </h3>
<p dir="auto"><strong><code>Player movement</code></strong> is designed to allow the player to move <strong><code>horizontally on the x-axis</code></strong>. Utilizing the <strong><code>rigidbody2D component</code></strong> within the unity engine I crafted a player movement that can be molded to be more specialized depending on what character you are. The wall jumping game mechanic is a feature only accessible to the Ninja Frog <strong><code>Jump Master</code></strong>.</p>
<br>
<p dir="auto"><strong><code>Wall Jumping </code></strong>gives the player the ability to <strong><code>push off of walls</code></strong>. Players will also reduce their fall speed by clinging to walls while in free fall. This feature was designed to help with precise jumping and mobility, in order to help the players to reach incredible heights.</p>
<br>
<p dir="auto">Traps designs were developed by implementing and utilizing the <strong><code>spline component</code></strong> into the designs of my traps. This provided the project with multiple saw trap variations that made platforming more exciting and challenging for players. The splines act as a <strong><code>path</code></strong> for the saws to follow and in doing so allows for a more optimized way of moving objects within a 2D space without the use of waypoints.</p>
<br>
<p dir="auto">The sprite animations provided the project with great visual impact that allows players to see the different states the player is in. By designing sprite animation logic the player is more visually appealing and can be easily identified as to when the player is in different health conditions, or on the move, or stationary.</p>
<br>

<h3 align="left" dir="auto"> UI Programming </h3>
<p dir="auto">Developing an in-game user interface that provided the project with a visual indicator of the amount of points accumulated and collectables collected. 
  By design the player ui logic the game keeps real time updates on the points collected and fruits and orbs collected throughout the level for the players to see at all times.</p>
<br>
