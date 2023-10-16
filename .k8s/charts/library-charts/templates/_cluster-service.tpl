{{- define "clusterip.service" -}}
{{- $ := index . 0 -}}
{{- $port := index . 1 -}}
{{- $targetport := index . 2 -}}
apiVersion: v1
kind: Service
metadata:
  name: {{$.Release.Name}}-service
  namespace: {{$.Release.Namespace}}
spec:
  selector:
    app: {{$.Release.Name}}
  type: ClusterIP
  ports:
  - port: {{$port}}
    targetPort: {{$targetport}}
{{- end -}}