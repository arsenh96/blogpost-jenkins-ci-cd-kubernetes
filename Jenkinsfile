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
                bat 'dotnet restore'
            }
        }
        
        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }
        
        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }

        stage('Deploy Placeholder') {
            steps {
                echo 'Deploy stap komt hier later.'
            }
        }
    }
}
