#version 330
 
precision mediump float;

uniform mat4 u_model;
uniform mat4 u_cameraView;
uniform vec3 u_cameraPosition;

uniform vec3 u_materialSpecular;
uniform float u_materialSpecExponent;

#define MAX_LIGHTS 10
uniform int u_numLights;
uniform struct Light {
   vec4 position;
   vec3 intensities; //a.k.a the color of the light
   float attenuation;
   float ambientCoefficient;
   float coneAngle;
   vec3 coneDirection;
} u_allLights[MAX_LIGHTS];

in vec3 o_pos;
in vec3 o_norm;
in vec4 o_color;
out vec4 out_frag_color;
 
vec3 ApplyLight(Light light, vec3 surfaceColor, vec3 normal, vec3 surfacePos, vec3 surfaceToCamera) {
    
	vec3 surfaceToLight;
    float attenuation = 1.0;

    if(light.position.w == 0.0) {
        //point light
		// poniewaz nie odejmuje od light.position SurfacePos to jest to swiatlo w nieskonczonosci (np. slonce)
		// o kierunku padania promieni takim samym w kazdym punkcie. Po odjeciu surfacePos byloby to zwykle swiatlo punktowe
        surfaceToLight = normalize(light.position.xyz);
        attenuation = 1.0; //no attenuation for point lights
    } else {
        //directional light
        surfaceToLight = normalize(light.position.xyz - surfacePos);
        float distanceToLight = length(light.position.xyz - surfacePos);
        attenuation = 1.0 / (1.0 + light.attenuation * pow(distanceToLight, 2));

        //cone restrictions (affects attenuation)
		float lightToSurfaceCos = dot(-surfaceToLight, normalize(light.coneDirection));
        float lightToSurfaceAngle = degrees(acos(lightToSurfaceCos));
        if(abs(lightToSurfaceAngle) > light.coneAngle)
            attenuation = 0.0;
		else
			attenuation *= (1.0 - abs(lightToSurfaceAngle / light.coneAngle));
   }

   //ambient
    vec3 ambient = light.ambientCoefficient * surfaceColor.rgb * light.intensities;

    //diffuse
    float diffuseCoefficient = max(0.0, dot(normal, surfaceToLight));
    vec3 diffuse = diffuseCoefficient * surfaceColor.rgb * light.intensities;
    clamp(diffuse, 0.0, 1.0);

    //specular
    float specularCoefficient = 0.0;
    if(diffuseCoefficient > 0.0)
        specularCoefficient = pow(max(0.0, dot(surfaceToCamera, reflect(-surfaceToLight, normal))), u_materialSpecExponent);
    vec3 specular = specularCoefficient * u_materialSpecular * light.intensities;
	clamp(specular, 0.0, 1.0);

    //linear color (color before gamma correction)
    return attenuation*(ambient + diffuse + specular);
}

void main()
{
	vec3 normal = normalize(transpose(inverse(mat3(u_model))) * o_norm);
    vec3 surfacePos = vec3(u_model * vec4(o_pos, 1));
    vec4 surfaceColor = o_color;
    vec3 surfaceToCamera = normalize(u_cameraPosition - surfacePos);

    //combine color from all the lights
    vec3 linearColor = vec3(0);
    for(int i = 0; i < u_numLights; ++i){
        linearColor += ApplyLight(u_allLights[i], surfaceColor.rgb, normal, surfacePos, surfaceToCamera);
    }
    
    //final color (after gamma correction)
    vec3 gamma = vec3(1.0/2.2);
    out_frag_color = vec4(pow(clamp(linearColor, 0.0, 1.0), gamma), surfaceColor.a);
}