# TheRecruiter
small CI/CD example with circle ci and deployment to AWS EB


# Build and deployment pipeline
The build and deployment is hosted at CircleCi.com, where the pipeline is configured through the ".circleci/config.yml" configuration file.

This file includes all the steps for building, "testing" and deploying TheRecruiter to AWS Beanstalk.

The current step for this microservice is:
- Build, which builds & restores packages for the.NET sln
- Build also builds the project in release mode in a folder called ./dist
- At the end of build, the files in the dist folder is persisted to circleci workspace.
- When the build step is complete, the deploy step will take over, but only if the current branch is master.
- Deploy step installs the Aws EB cli and sets up the workspace from the previous step. 
- Afterwards the deploy step zips the dist and docker file into a zip file called app.zip
- When the zipfile is finished the eb deploy command is fired based on the configuration from ".elasticbeanstalk/config.yml" file


# I want more steps
This should be easy, adjust the ".circleci/config.yaml" file to include the new step. Remember in the end of the yaml file, there is a workflow section. Put your newly created build step into the workflow for when it's required to run. 

Commit the file and check your build in circleci.

# Secrets
Secrets like AWS access key's are kept in CircleCi's managed environment and are kept clean from any STDIN/STDOUT based on any build in this repository
