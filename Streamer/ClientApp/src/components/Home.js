import React, { Component } from 'react';
import { VideoPlayer } from './VideoPlayer';

export class Home extends Component {
  static displayName = Home.name;

  render () {
      const videoJsOptions = {
          autoplay: true,
          controls: true,
          sources: [{
              src: 'http://localhost:8080/live/tests.m3u8',
              type: 'application/x-mpegURL'
          }]
      }

      return <VideoPlayer {...videoJsOptions} />
  }
}
