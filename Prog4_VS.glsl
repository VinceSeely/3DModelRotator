#version 400
	
	layout (location = 0) in vec3 VertexPosition;
	layout (location = 1) in vec3 VertexNormal;
	layout (location = 2) in vec3 VertexColor;
	
	
	out vec3 LightIntensity;
	
   uniform float Shininess;
	uniform float GlobalAmbient;
	uniform vec3 LightPosition;
	uniform vec3 LightColor;
	uniform mat4 ModelMatrix;
	uniform mat4 ViewMatrix;

	uniform mat4 NormalMatrix;
	uniform mat4 ProjectionMatrix;
	
	void getEyeSpace( out vec3 norm, out vec4 position )
	{
	  norm = normalize(vec3(NormalMatrix * vec4(VertexNormal,0.0)));
	  position = ViewMatrix * ModelMatrix * vec4(VertexPosition,1.0);
	}
	
	vec3 phongModel( vec4 position, vec3 norm )
	{
	  vec3 s = normalize(vec3(ViewMatrix * vec4(LightPosition,1.0)  - position));
	  vec3 v = normalize(-position.xyz);
	  vec3 r = reflect( -s, norm );
	  vec3 ambient = vec3(GlobalAmbient) * VertexColor;
	  float sDotN = max( dot(s,norm), 0.0 );
	  vec3 diffuse = LightColor * VertexColor * sDotN;
	  vec3 spec = vec3(0.0);
	  if( Shininess > 0 && sDotN > 0.0 )
		  spec = LightColor * VertexColor *
				 pow( max( dot(r,v), 0.0 ), Shininess );
	  return ambient + diffuse + spec;
	}
	
	void main()
	{
	  vec3 eyeNorm;
	  vec4 eyePosition;
	  // Get the position and normal in eye space
	  getEyeSpace(eyeNorm, eyePosition);
	  // Evaluate the lighting equation.
	  LightIntensity = phongModel( eyePosition, eyeNorm );
	  gl_Position = ProjectionMatrix * ViewMatrix * ModelMatrix * vec4(VertexPosition,1.0);
	}	