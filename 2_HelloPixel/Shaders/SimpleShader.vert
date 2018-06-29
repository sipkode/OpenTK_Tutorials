#version 450 core

layout(location = 0) in vec3 vertexPosition_modelspace;

void main()
{
	// Let's draw a single point!
	gl_Position = vec4( 0.25, -0.25,  0.5,  1.0);
}