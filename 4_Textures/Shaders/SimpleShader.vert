﻿#version 450 core

layout (location = 0) in vec3 position;
layout(location = 1) in vec2 textureCoordinate;

out vec2 vs_textureCoordinate;

void main(void)
{
	gl_Position = vec4(position,1);
	vs_textureCoordinate = textureCoordinate;
}