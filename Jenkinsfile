pipeline {
    agent any 
    environment {
        DOCKER_USERNAME = 'arsenharutjunjan'
        DOCKER_PASSWORD = 'Password123!'
        KUBECONFIG = 'C:\\Users\\arsen\\.kube\\config' 
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Test') {
            steps {
                dir('HelloWorldWebApp.Tests') {
                    bat 'dotnet test'
                }
            }
        }
        stage('Docker Build and Push') {
            steps {
                sh 'pwd'
                sh 'ls -al'
                sh '''
                    echo "$DOCKER_PASSWORD" | docker login -u $DOCKER_USERNAME --password-stdin
                    docker build -t $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes -f HelloWorldWebApp/Dockerfile .
                    docker push $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes:latest
                '''
            }
        }
        stage('Kubernetes Deployment') {
            steps {
                script {
                    try {
                        bat 'kubectl apply -f kubernetes/HelloWorldWebApp.yaml' 
                    } catch (err) {
                        echo "Failed to apply kubernetes/HelloWorldWebApp.yaml: ${err}"
                        bat 'kubectl get all' 
                    }
                }
            }
        }
        stage('Verify Deployment') {
            steps {
                bat 'kubectl get deployments' 
            }
        }
    }
}
