import React from 'react';
import { VideoPlayer } from './VideoPlayer';

export class Video extends React.Component {

    constructor(props) {
        super(props);            
      }    
 
    render() {
        const videoJsOptions = {
            autoplay: true,
            controls: true,
            sources: [{
                src: 'http://localhost:8080/live/tests.m3u8',
                type: 'application/x-mpegURL'
            }]
        }

        return (
            <div className="video">
                <p>{this.props.name}</p>
            
                <VideoPlayer {...videoJsOptions} />
          
            </div>
        )
    }
}