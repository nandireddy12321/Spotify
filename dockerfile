# Use the official Node.js image as a base image
FROM node:14 AS build

# Set the working directory
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the entire project files to the working directory
COPY . .

# Build the Angular app
RUN npm run build --prod

# Use a lightweight web server for serving the Angular app in production
FROM nginx:alpine AS final

# Copy the built Angular app to the default Nginx public directory
COPY --from=build /app/dist/spotify /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Command to run Nginx
CMD ["nginx", "-g", "daemon off;"]
