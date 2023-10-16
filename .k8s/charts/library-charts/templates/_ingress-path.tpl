{{- define "ingress-path" -}}
{{- $ := index . 0 }}
{{- $path := index . 1 }}
{{- $appname := index . 2 }}
{{- $port := index . 3 }}
{{- $host := index . 4 }}
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: {{$appname}}
  namespace: {{$.Release.Namespace}}
spec:
  ingressClassName: nginx
  rules:
  - host: {{$host}}
    http:
      paths:
      - path: {{$path}}
        pathType: Prefix
        backend:
          service:
            name: {{$appname}}-service
            port:
              number: {{$port}}
{{- end -}}
