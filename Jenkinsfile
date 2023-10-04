pipeline {
    agent any 

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }
        
        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
        
        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }

        stage('Deploy') {
            steps {
                sh './deploy.sh' 
            }
        }
    }
}
