# Stage 1: Build the Angular application
FROM node:20-alpine AS build

# Set the working directory
WORKDIR /app

# Copy package.json and package-lock.json (if available)
COPY package*.json ./

# Install dependencies
RUN npm ci --only=production

# Copy the entire source code
COPY . .

# Build the Angular application for production
RUN npm run build

# Stage 2: Serve the application with Nginx
FROM nginx:alpine AS runtime

# Copy the built application from the build stage
COPY --from=build /app/dist/psych-appointments-client/browser /usr/share/nginx/html

# Copy custom nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
