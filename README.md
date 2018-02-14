# TheRecruiter
small CI/CD example with circle ci and deployment to AWS EB


# Build and deployment pipeline
The build and deployment is hosted at CircleCi.com, where the pipeline is configured through the ".circleci/config.yml" configuration file.

This file includes all the steps for building, "testing" and deploying TheRecruiter to AWS Beanstalk.

The current step for this microservice is:
- Build step
  - Restores packages for the sln solution
  - Builds the sln solution in release mode
  - Places the compiled dll's in a folder called ./dist
  - At the end of build, the files in the dist folder is persisted to circleci workspace.
- Deploy step
  - Installs the AWS EB CLI 
  - Attaches the workspace from the build pipeline
  - Zips the dist and docker file into a zip file called app.zip
  - Fires the command to "eb deploy" which uploads and deploy the zip file, based on the config from /.elasticbeanstalk/config.yml


# I want more steps
This should be easy, adjust the ".circleci/config.yaml" file to include the new step. Remember in the end of the yaml file, there is a workflow section. Put your newly created build step into the workflow for when it's required to run. 

Commit the file and check your build in circleci.

Circleci documentation: https://circleci.com/docs/2.0/

# Secrets
Secrets like AWS access key's are kept in CircleCi's managed environment and are kept clean from any STDIN/STDOUT based on any build in this repository
