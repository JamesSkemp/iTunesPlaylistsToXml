<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs" version="2.0">
	<xsl:output method="html" version="4.0" encoding="UTF-8" indent="yes"/>
    <xsl:key name="tracks-by-album" match="track" use="album"/>
    <xsl:template match="/">
        <html>
            <head>
                <title>
                    <xsl:value-of select="/playlist/@name"/>
                </title>
            </head>
            <body>
                <h1>Playlist: <xsl:value-of select="/playlist/@name"/></h1>
                <p>The following <xsl:value-of select="/playlist/@tracks"/> tracks are in the playlist <xsl:value-of select="/playlist/@name"/>, created by <xsl:value-of select="/playlist/information/name"/>, which has a total run time of <xsl:value-of select="/playlist/@time"/>.</p>
                <ul id="NameArtistAlbumPlay">
                	<xsl:for-each select="/playlist/track[count(. | key('tracks-by-album', album)[1]) = 1]">
                		<xsl:sort select="album"/>
                		<li><xsl:value-of select="album"/>
                			<ul>
                				<xsl:for-each select="key('tracks-by-album', album)">
                					<li><xsl:value-of select="name"/> - Track <xsl:value-of select="trackNumber"/> on Disc <xsl:value-of select="discNumber"/></li>
                				</xsl:for-each>
                			</ul>
                		</li>
                	</xsl:for-each>
                	
                	
                </ul>
                <!-- Please keep the following. Thank you! -->
                <p>Playlist last updated <xsl:value-of select="/playlist/information/updated"/>. Output generated by <a href="http://jamesrskemp.com/apps/iTunesPlaylists2Xml/?xslt" onclick="window.open(this.href);return false;">iTunes Playlists to Xml</a>.</p>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
